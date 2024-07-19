const PROXY_CONFIG = [
  {
    context: [
      '/api/company',
    ],
    target: 'https://localhost:7146',
    secure: false
  }
]

module.exports = PROXY_CONFIG;
