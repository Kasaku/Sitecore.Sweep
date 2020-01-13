# Sitecore.Sweep

### What is this?

A simple extensible module for Sitecore for the automatic cleaning of HTML in Items.

### Why?

Because sometimes you want tighter control over the HTML that is produced in Rich-Text fields by your content editors. Sweep simply tidies up the HTML upon saving, following a customizable pipeline that processes the HTML.

### What sort of tidying?

Anything really, but some included options are:

- Removing inline styling
- Removing invalid classes (supports both whitelisting + blacklisting class names)
- Removing empty elements (e.g. `<p></p>`)
- Fixing shoddy headers (e.g. `<p><strong>My title!</strong></p>` --> `<h2>My title!</h2>`)
- Ensuring text is wrapped in paragraph tags if no root element is found
- Fixing nested paragraphs (e.g. `<p><p>My text</p></p>` --> `<p>My text</p>`)
- Removing non-breaking spaces, because they shouldn't be used for spacing text.
- Removing inner-elements from headers

It is by no means suggested that you should need to use all of these options, or that all of these make for Perfect HTML™. Every situation is different, and these are just some of the provided options you can use.

It's also very easy to add your own steps. Just extend `SweepCleanProcessor` and add your new processor to the `sweep.clean` pipeline.

### What does it use for cleaning?

The module makes use of the [HtmlAgilityPack](https://htmlagilitypack.codeplex.com/) library, which is already included with Sitecore.

### A bit drastic isn't it?

It's as drastic as you want it to be. There are plenty of times you won't want to use this approach, but on sites where you want to strictly control what is output, it's useful.

### Does it just update all Rich-Text fields?

By default it does nothing. It comes with two methods of determining what fields to update - a field matcher and a template matcher. These are configured in `App_Config/Include/Sweep/Sweep.config`.

- *Field Matcher* - This allows you to specify Field IDs that you want to be processed.
- *Template Matcher* - This allows you to specify Template IDs that you want all Rich-Text fields within to be updated.
- *AllRichText Matcher* - If you really want, you can enable this to just process *all* Rich-Text fields.

### Anything else to know?

There's also a new button added to the Rich Text Editor that allows the pipeline to be called on-demand whilst editing, regardless of what field is currently being edited.

### Ok. So do I need to build it?

You can grab the source and build it yourself to include in your project. But if you'd rather just work with a package, you can grab the latest release from the `dist` folder. The full-package will install the module as well as a Clean HTML button into the default Rich Text Editor profile.

The current release has been tested with Sitecore 6.6, 7.2, 8.2 and 9.3, and is expected to work with versions in-between. Please raise an issue if you come across any problems.

### Sitecore 6.x

Sitecore 6.6 uses a different version of HtmlAgilityPack, version `1.4.0.0`. If you are building from source, you will need to account for this as the solution currently doesn't. However if you just want the build, the `dist` folder already contains a working build for Sitecore 6.6.

### Sidecore 9.x

Sitecore 9.0 - 9.3 also use a different version of HtmlAgilityPack, version `1.4.9.5`. You can use the regular build of Sitecore.Sweep with this version, but should include this assembly binding redirect in your `web.config`:

```xml
<dependentAssembly>
	<assemblyIdentity name="HtmlAgilityPack" publicKeyToken="bd319b19eaf3b43a" culture="neutral" />
	<bindingRedirect oldVersion="1.4.0.0-1.4.9.5" newVersion="1.4.9.5" />
</dependentAssembly>
```
