import React, { useEffect, useRef } from 'react';
import ReactMarkdown from "react-markdown";
import './ChatInterface.css';


const ChatInterface = ({
    messages,
    messageInput,
    setMessageInput,
    onSendMessage,
    onBackToForm,
    greetingName,
    currentThreadId 
}) => {
    const messagesEndRef = useRef(null);

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    };

    useEffect(scrollToBottom, [messages]);

    const handleKeyPress = (e) => {
        if (e.key === 'Enter' && !e.shiftKey) { // Send on Enter, allow Shift+Enter for new line
            e.preventDefault(); // Prevents adding a new line in the input after sending
            onSendMessage();
        }
    };

    return (
        <div id="chatInterface" className="chat-interface">
            <div className="chat-header">
                <div className="chat-header-info">
                    <img src="https://storage.googleapis.com/workspace-0f70711f-8b4e-4d94-86f1-2a93ccde5887/image/f8044ba5-0f66-4dd1-bbdb-f31c03ff23f1.png" alt="Assistant avatar" className="avatar-image" />
                    <div>
                        <h2>Travel Assistant for {greetingName}</h2>
                        {currentThreadId && <p className="thread-id-display">Thread ID: {currentThreadId}</p>}
                    </div>
                </div>
                <button id="backToFormBtnChat" className="back-button" onClick={onBackToForm}>
                    Back to Form
                </button>
            </div>

            <div id="messagesArea" className="messages-area">
                {messages.map(msg => (
                    <div key={msg.id} className={`message-bubble-container ${msg.sender === 'user' ? 'user-message' : 'assistant-message'}`}>
                        <div className="chat-bubble">  <ReactMarkdown>{msg.text}</ReactMarkdown></div>
                    </div>
                ))}
                <div ref={messagesEndRef} />
            </div>

            <div className="input-area">
                <textarea
                    id="messageInput"
                    placeholder="Type your message..."
                    value={messageInput}
                    onChange={(e) => setMessageInput(e.target.value)}
                    onKeyPress={handleKeyPress}
                    rows="1" 
                />
                <button id="sendBtn" className="send-button" onClick={onSendMessage} disabled={!messageInput.trim()}>
                    Send
                </button>
            </div>
            <p className="disclaimer-text">Responses may take a few moments. You can use Shift+Enter for a new line.</p>
        </div>
    );
};

export default ChatInterface;