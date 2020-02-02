'use strict';
const { createContainer, asClass, asValue } = require('awilix');
const { createServer } = require('./httpServer');

module.exports.MyTog = function () {
    const container = createContainer();

    container.register({
        // Constants
        // Use cases
        // Repositories
        // Services
    });

    const api = createServer({ container });

    return {
        run: api.run,
        stop: api.stop
    }
}