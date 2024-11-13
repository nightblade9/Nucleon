# Nucleon

:warning: Nucleon is still a proof-of-concept, and is not production ready! :warning:

Build a cross-platform PC app or game with .NET technologies. Inspired by Electron.NET and friends.

# Developer Experience

Using VSCode, run the solution. It should launch two windows: a stand-alone browser (which you can close), and a Chromium window for your app. You can browse either one, and VSCode will automatically hit all the breakpoints you've set.

## FAQ

### Why use Chromium?

I considered, and discarded, the following alternative browser options, none of which are viable:

- CefSharp (minimal example crashes, code crashes citing a missing DLL, but the DLL is there)
- ChromiumEmbedded/cef on git: requires additional work to embed, it's 200MB
- EO.WebBrowser (requires a license)
- SharpBrowser (requires building the browser, is Windows-only)

On top of that, Chromium is widely-used (Chrome, IE, etc.) and developers are (hopefully) more familiar with its HTML/CSS/JS quirks.