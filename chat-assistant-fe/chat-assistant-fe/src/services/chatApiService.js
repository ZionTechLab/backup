
// const BASE_URL="http://localhost:3000"
const BASE_URL="https://app-openai-chat-assistance-be-grdpdxbkdwctgpfe.southeastasia-01.azurewebsites.net/"
export const initChatSession = async () => {
    try {
        const response = await fetch(`${BASE_URL}/chat/init`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        console.log(`[chatApiService.initChatSession] Real API success. Thread ID: ${data.threadId}`);
        return data;
    } catch (error) {
        console.error('[chatApiService.initChatSession] Real API error:', error);
        throw error;
    }
};

export const sendMessageToThread = async (threadId, messageContent, messageType = 'userMessage') => {
    console.log(`[chatApiService.sendMessageToThread] Sending message of type "${messageType}" to thread ${threadId}. Message content: "${messageContent}"`);
    if (!threadId) {
        return Promise.reject(new Error("threadId is required to send a message."));
    }

    try {
        console.log("start")
        const response = await fetch(`${BASE_URL}/chat/${threadId}/message`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                message: messageContent
            })
        });
      console.log(response)
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json(); 
          console.log(data)
        console.log(`[chatApiService.sendMessageToThread] (${messageType}) API success for thread ${threadId}.`);
        return data;

    } catch (error) {
        console.error(`[chatApiService.sendMessageToThread] (${messageType}) API error for thread ${threadId}:`, error);
        throw error;
    }
};

// export const initChatSession = async () => {
//     return new Promise((resolve, reject) => {
//         setTimeout(() => {
//             if (Math.random() > 0.1) { // 90% success
//                 const newThreadId = `thread_api_${Date.now()}`;
//                 console.log(`[chatApiService.initChatSession] Simulated success. New Thread ID: ${newThreadId}`);
//                 resolve({ threadId: newThreadId });
//             } else {
//                 console.error("[chatApiService.initChatSession] Simulated API error.");
//                 reject(new Error("Simulated API error: Failed to initialize chat session."));
//             }
//         }, 800); 
//     });
// };


// export const sendMessageToThread = async (threadId, messageContent, messageType = 'userMessage') => {
//     if (!threadId) {
//         return Promise.reject(new Error("threadId is required to send a message."));
//     }

//     return new Promise((resolve, reject) => {
//         setTimeout(() => {
//             if (Math.random() > 0.1) { // 90% success
//                 console.log(`[chatApiService.sendMessageToThread] (${messageType}) Simulated success for thread ${threadId}. Message: "${messageContent.substring(0, 30)}..."`);
//                 // Simulate different responses based on messageType if needed,
//                 // or a generic structure. For now, a generic one similar to user messages.
//                 const response = {
//                     // Assuming the server confirms the sent message and provides its own ID for it
//                     confirmedMessage: {
//                         id: `server_msg_${Date.now()}`,
//                         text: messageContent,
//                         sender: messageType === 'initialFormData' ? 'system' : 'user', // Or just 'user' if backend handles 'system' type
//                         status: 'sent',
//                         threadId: threadId
//                     },
//                 };
//                 // Add an assistant reply only for 'userMessage' type for this simulation
//                 if (messageType === 'userMessage') {
//                     response.assistantReply = {
//                         id: `assistant_api_${Date.now()}`,
//                         text: `Assistant API response to: "${messageContent.substring(0,20)}..."`,
//                         sender: 'assistant',
//                         status: 'received',
//                         threadId: threadId
//                     };
//                 }
//                 resolve(response);
//             } else {
//                 console.error(`[chatApiService.sendMessageToThread] (${messageType}) Simulated API error for thread ${threadId}.`);
//                 reject(new Error(`Simulated API error: Failed to send ${messageType}.`));
//             }
//         }, 1000); // Simulate network delay
//     });
// };

