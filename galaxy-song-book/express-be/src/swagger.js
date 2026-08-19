const fs = require('fs');
const path = require('path');
const swaggerJSDoc = require('swagger-jsdoc');
const swaggerUi = require('swagger-ui-express');

const options = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'Service Plus API',
      version: '1.0.0',
      description: 'API documentation for Service Plus backend',
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
  },
  // Include feature route files so paths are discovered
  apis: ['./src/routes/*.js', './src/features/**/*.js'],
};

// Try to load pre-generated OpenAPI spec; fallback to swagger-jsdoc at runtime
let swaggerSpec;
const generatedSpecPath = path.join(__dirname, 'swagger-output.json');
if (fs.existsSync(generatedSpecPath)) {
  swaggerSpec = require(generatedSpecPath);
} else {
  swaggerSpec = swaggerJSDoc(options);
}

function setupSwagger(app) {
  app.use('/api/docs', swaggerUi.serve, swaggerUi.setup(swaggerSpec));
}

module.exports = setupSwagger;
