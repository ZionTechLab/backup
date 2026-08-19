// const { app } = require('@azure/functions');

// app.http('whitelistIp', {
//     methods: ['GET', 'POST'],
//     authLevel: 'anonymous',
//     handler: async (request, context) => {
//         context.log(`Http function processed request for url "${request.url}"`);

//         const name = request.query.get('name') || await request.text() || 'world';

//         return { body: `Hello, ${name}!` };
//     }
// });


// const axios = require("axios");
// const { DefaultAzureCredential } = require("@azure/identity");
// const { SqlManagementClient } = require("@azure/arm-sql");
// require('dotenv').config();

// module.exports = async function (context, req) {
//     const ip = (await axios.get("https://api.ipify.org")).data;

//     const credential = new DefaultAzureCredential();
//     const client = new SqlManagementClient(credential, process.env.SUBSCRIPTION_ID);

//     const result = await client.firewallRules.createOrUpdate(
//         process.env.RESOURCE_GROUP,
//         process.env.SQL_SERVER_NAME,
//         "Dynamic-IP-Rule",
//         {
//             startIpAddress: ip,
//             endIpAddress: ip
//         }
//     );

//     context.res = {
//         body: `✅ Whitelisted IP: ${ip}`
//     };
// };
const axios = require("axios");
const { DefaultAzureCredential } = require("@azure/identity");
const { SqlManagementClient } = require("@azure/arm-sql");
const { app } = require('@azure/functions');
require('dotenv').config();

app.http('whitelistIp', {
    methods: ['GET'],
    authLevel: 'anonymous',
    handler: async (request, context) => {
        try {
            const ip = (await axios.get("https://api.ipify.org")).data;

            const credential = new DefaultAzureCredential();
            const client = new SqlManagementClient(credential, process.env.SUBSCRIPTION_ID);

            const result = await client.firewallRules.createOrUpdate(
                process.env.RESOURCE_GROUP,
                process.env.SQL_SERVER_NAME,
                "Dynamic-IP-Rule",
                {
                    startIpAddress: ip,
                    endIpAddress: ip
                }
            );

            return {
                status: 200,
                body: `✅ Whitelisted IP: ${ip}`
            };
        } catch (error) {
            context.error("🔥 Error:", error.message);
            return {
                status: 500,
                body: `❌ Failed: ${error.message}`
            };
        }
    }
});
