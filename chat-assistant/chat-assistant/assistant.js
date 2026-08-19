//  import { AzureOpenAI } from "openai";
// import "dotenv/config";

// const assistantsClient = new AzureOpenAI({
//   apiKey: process.env.AZURE_OPENAI_KEY,
//   endpoint: process.env.AZURE_OPENAI_ENDPOINT,
//   apiVersion: "2024-05-01-preview",
// });

// const options = {
//   model: "gpt-35-turbo",
//   name: "TripGenie",
//   instructions: `You are a friendly, knowledgeable tour itinerary assistant named TripGenie.
//     You help users plan travel based on destination, time, and preferences. 
//     Use uploaded documents to suggest ideas.`,
//   tools: [{ type: "file_search" }],
//   tool_resources: {
//     file_search: {
//       vector_store_ids: ["vs_TZPPw5aBoNOTn7DkZvwHpIna"],
//     },
//   },
//   temperature: 0.5,
//   top_p: 1,
// };

// export async function createAssistant() {
//   const assistant = await assistantsClient.beta.assistants.create(options);
//   return assistant;
// }

// export default assistantsClient;




import { AzureOpenAI } from "openai";
import "dotenv/config";

const assistantsClient = new AzureOpenAI({
  apiKey: process.env.AZURE_OPENAI_KEY,
  endpoint: process.env.AZURE_OPENAI_ENDPOINT,
  apiVersion: "2024-05-01-preview",
});

const options = {
  model: "gpt-35-turbo", // or your deployed model name
  name: "TripGenie",
  instructions: `You are a friendly, knowledgeable tour itinerary assistant named TripGenie.
    You help users plan travel based on destination, time, and preferences. 
    Use uploaded documents to suggest ideas.give the respons in markdown format`,
  tools: [{ type: "file_search" }],
  tool_resources: {
    file_search: {
      vector_store_ids: ["vs_TZPPw5aBoNOTn7DkZvwHpIna"], // your vector store id
    },
  },
  temperature: 0.5,
  top_p: 1,
};

export async function createAssistant() {
  const assistant = await assistantsClient.beta.assistants.create(options);
  return assistant;
}

export default assistantsClient;
