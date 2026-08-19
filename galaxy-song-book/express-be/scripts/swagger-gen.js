const path = require('path');
const swaggerAutogen = require('swagger-autogen')({ openapi: '3.0.0' });

const outputFile = path.join(__dirname, '..', 'src', 'swagger-output.json');
const endpointsFiles = [
  path.join(__dirname, '..', 'src', 'routes', 'index.js').replace(/\\/g, '/'),
];

const doc = {
  info: {
    title: 'Service Plus API',
    version: '1.0.0',
    description: 'Auto-generated from Express routes',
  },
  servers: [
    {
      url: process.env.API_BASE_URL || 'http://localhost:3000',
      description: 'Default server',
    },
  ],
  components: {
    securitySchemes: {
      bearerAuth: {
        type: 'http',
        scheme: 'bearer',
        bearerFormat: 'JWT',
      },
    },
  },
};

swaggerAutogen(outputFile, endpointsFiles, doc)
  .then(({ success }) => {
    if (success) {
      console.log('Swagger spec generated at', outputFile);
    } else {
      console.warn('Swagger spec generation reported failure');
    }
  })
  .catch((err) => {
    console.error('Swagger spec generation failed:', err);
    process.exitCode = 1;
  });
