const express = require('express')
const auth = require('../Auth0authentication')
const router = express.Router()

router.use(function timeLog(req, res, next) {
  console.log('Time: ', Date.now())
  next()
})

router.get('/ping', auth.checkJwt(), function (req, res) {
  res.json("{status:'success'}")
})

module.exports = router