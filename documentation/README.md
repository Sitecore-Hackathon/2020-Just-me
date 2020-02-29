# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** Sitecore Marketplace Website

This module provie the nessesary features to have a Marketplace Website. This features include the upload marketplace item and the download marketplace item. Also the download feature is like a Gated Download that you need first fill your personal information to get the download link.

The problem solved is how can dynamic upload the content without sitecore admin interface, and provide basic functionality of the marketplace. It is solve integrated with Sitecore Forms.


## Pre-requisites

- Nuget Packages:
    - Sitecore.Mvc
    - Sitecore.Mvc.Analytics
    - Constellation.Foundation.Mvc
    - Constellation.Foundation.Mvc.Patterns
    - Constellation.Foundation.Datasources
    - Constellation.Foundation.ModelMapping
- Sitecore Packages located at /App_Data/packages:
    - Constellation-Foundation-Datasources-Items.zip
    - Sitecore Forms Extensions For Sitecore 9.3-3.0.zip

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ???
3. Profit

## Configuration

How do you configure your module once it is installed? Are there items that need to be updated with settings, or maybe config files need to have keys updated?

Remember you are using Markdown, you can provide code samples too:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="MyModule.Setting" value="Hackathon" />
    </settings>
  </sitecore>
</configuration>
```

## Usage

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.

Please include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://placeimg.com/480/240/any "Random")

## Video

[![Sitecore Hackathon 2020 - Just me!](https://img.youtube.com/vi/fQ8qPVl5AoA/0.jpg)](https://youtu.be/fQ8qPVl5AoA)
