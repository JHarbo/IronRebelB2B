var prerendering = require('aspnet-prerendering');

module.exports = prerendering.createServerRenderer(function (params) {
    return new Promise(function (resolve, reject) {
        var result = '<h1>Loading...</h1>';

        resolve({ html: result });
    });
});