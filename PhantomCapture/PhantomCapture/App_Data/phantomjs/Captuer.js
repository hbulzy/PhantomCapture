var system = require('system');

var url = system.args[1];
console.log(url);
var path = system.args[2];
var format = system.args[3];
var page = require('webpage').create();
if (system.args.length >= 6)
{
	page.viewportSize = { width: system.args[4], height: system.args[5] };
}

page.open(url, function () {
    window.setTimeout(function () {
    	page.render(path, {format:format});
        phantom.exit();
    }, 200);
});