'use strict'

const { MyTog } = require('./awilixBootstrapper');

const myTog = MyTog();
process.on('uncaughtException', function (err) {
    console.log('Caught unhandled exception.')
    console.log(err)
    myTog.stop()
})


myTog.run()