# PowerShell App

A Blazor Server web application that runs PowerShell network diagnostic tools from a browser UI.

## Features

- **Ping** — Tests connectivity to a host using `Test-Connection`, displays reply times, TTL, packet stats and min/max/avg latency
- **DNS Lookup** — Resolves DNS records for a host using `Resolve-DnsName`, displays Name, Type, IPAddress, TTL and more

## Tech Stack

- [.NET 10](https://dotnet.microsoft.com/)
- [Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [PowerShell SDK](https://github.com/PowerShell/PowerShell) (`System.Management.Automation`)

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows (required for `System.Management.Automation`)

## Getting Started

1. **Clone the repository**
git clone https://github.com/Nam6665/PowerShell-app.git cd PowerShell-app


2. **Run the application**
dotnet run --project PowerShell-app

3. **Open in browser**

## Usage

1. Enter a URL or hostname in the input field (e.g. `google.com` or `https://google.com`)
2. Click **Ping**, **DNS Lookup**, or **Speed Test**
3. Results are displayed in the terminal-style output box below each button
