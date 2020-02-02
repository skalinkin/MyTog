'use strict';
const express = require('express')
const logger = require('morgan')
const bodyParser = require('body-parser')
const cookieParser = require('cookie-parser');
const auth = require('./Auth0authentication')

module.exports.createApp = function () {
    const app = new express();

    app.use(logger('dev'))
    app.use(auth.checkJwt())
    app.use(bodyParser.urlencoded({ extended: false }))
    app.use(bodyParser.text())
    app.use(bodyParser.json())
    app.use(cookieParser()); 


    app.use(require('./ping/controller'))
    return app
}