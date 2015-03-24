
[Selenium IDE Plugin for Firefox](http://release.seleniumhq.org/selenium-ide/2.8.0/selenium-ide-2.8.0.xpi) allows you to easily record, edit and replay test cases in the browser.

During playback if you get a timing issue, try using pause setting the target to the number of milliseconds you want to delay in order to fine tune the playback.

# selenium-webdriver

Demo how to create UI tests in c#

Show how to create snapshots of browser.

https://github.com/agross/mspec-samples/tree/master/WebSpecs/LoginApp.Selenium.Specs


if running on mac:
brew install selenium-server-standalone

to see where homebrew installs packcages
> brew --cache

to start selenium server
> java -jar /Library/Caches/Homebrew/selenium-server-standalone-2.44.0.jar


ref
https://code.google.com/p/selenium/wiki/WebDriverJs

## Inspect HTML and use jquery in browser to test DOM selectors for example:

```
$("#UserName").css("border", "3px solid red")

$("#message").css("border", "3px solid green")
```

The submit() function is there to make life easier. You can use it on any element inside of form tags to submit that form
