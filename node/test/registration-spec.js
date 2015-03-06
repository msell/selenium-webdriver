var webdriver = require('selenium-webdriver'),
    By = require('selenium-webdriver').By,
    until = require('selenium-webdriver').until,
    chrome = require('selenium-webdriver/chrome'),
    firefox = require('selenium-webdriver/firefox'),
    chai = require('chai'),
    should = require('chai').should();


describe('new user registration', function () {

        describe('when invalid email is entered', function () {
            it('should display an invalid email error', function () {
                var driver = new webdriver.Builder()
                    .usingServer('http://127.0.0.1:4444/wd/hub')
                    .forBrowser('firefox')
                    .build();


                driver.get('http://quickstart-frontend.herokuapp.com/#/register');

                driver.findElement(By.name('email')).sendKeys('CookieMonster');

                var errorMessage = '';
                driver.findElement(By.xpath('/p'))
                    .then(function (result) {
                            errorMessage = result;
                        }


                        //errorMessage.should().contain('Email is invalid');
                );
            })
        })
});