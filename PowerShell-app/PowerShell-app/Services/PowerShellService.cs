using System.Management.Automation;

namespace PowerShell_app.Services
{
    public class PowerShellService
    {
        public string ParseHost(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;
            return new Uri(url).Host;
        }

        public async Task<string> RunScript(string script)
        {
            using var ps = PowerShell.Create();
            ps.AddScript(script);
            var results = await ps.InvokeAsync().ConfigureAwait(false);
            return string.Join(Environment.NewLine, results.Select(r => r.ToString()));
        }

        public Task<string> RunPing(string url) =>
            RunScript($"ping {ParseHost(url)}");

        public async Task<string> DnsLookUp(string url)
        {
            using var ps = PowerShell.Create();
            ps.AddScript($"Resolve-DnsName {ParseHost(url)}");
            var results = await ps.InvokeAsync().ConfigureAwait(false);

            var separator = Environment.NewLine + new string('-', 40) + Environment.NewLine;
            return string.Join(separator, results.Select(r =>
            {
                var fields = new (string Label, string Key)[]
                {
                    ("Name",      "Name"),
                    ("Type",      "Type"),
                    ("IPAddress", "IPAddress"),
                    ("IPv6",      "IP6Address"),
                    ("NameHost",  "NameHost"),
                    ("Section",   "Section"),
                    ("TTL",       "TTL"),
                };
                var parts = fields
                    .Select(f => (f.Label, Value: r.Properties[f.Key]?.Value))
                    .Where(f => f.Value != null)
                    .Select(f => $"{f.Label,-10} {f.Value}");

                return parts.Any() ? string.Join(Environment.NewLine, parts) : r.ToString();
            }));
        }
    }
}

