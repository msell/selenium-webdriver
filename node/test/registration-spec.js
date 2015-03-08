var chai = require('chai'),
    assert = chai.assert,
    expect = chai.expect,
    should = chai.should(),
    webdriverio = require('webdriverio');

describe('my webdriverio tests', function () {

    this.timeout(99999999);
    var client = {};

    before(function (done) {
        client = webdriverio.remote({
            desiredCapabilities: {
                browserName: 'chrome'
            }
        });
        
        client.init(done);
    });

    it('Github test', function (done) {
        client
            .url('http://quickstart-frontend.herokuapp.com/#/register')
            .setValue('input[name=email]', 'cookieMonster')
            .getText('//p', function (err, emailError) {
                
                expect(emailError[0]).to.equal('Email is invalid');
            })
            .call(done);
    });

    after(function (done) {
        client.end(done);
    });
});