
var webdriver = require('selenium-webdriver'),
    By = require('selenium-webdriver').By,
    until = require('selenium-webdriver').until,
    chai = require('chai'),
    should = require('chai').should();


describe('new user registration', function(){
    
    describe('when invalid email is entered', function(){
        it('should display an invalid email error', function(){
            var driver = new webdriver.Builder()
                .forBrowser('firefox')
                .build();
            
            driver.get('http://quickstart-frontend.herokuapp.com/#/register');
           // driver.findElement(By.xPath('/p'))
        });
    })
})

