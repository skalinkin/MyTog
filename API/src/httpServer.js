'use strict';
const http = require('http')
const { createApp } = require('./expressApp');

module.exports.createServer = function(){
    const app = createApp()
    const server = http.createServer(app)    
    return {
        run() {
            var port = 3000;
            server.listen(port)
            console.log('Server started at http://localhost:' + port)
        },
        stop() {
            server.close()
        }
    }
}