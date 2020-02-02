'use strict';
const http = require('http')
const { createApp } = require('./expressApp');

module.exports.createServer = function(){
    const app = createApp()
    const server = http.createServer(app)    
    return {
        run() {
            server.listen(3000)
            console.log('Server started.')
        },
        stop() {
            server.close()
        }
    }
}