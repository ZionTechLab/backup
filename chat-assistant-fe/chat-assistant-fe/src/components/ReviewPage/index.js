import React from 'react';
import './ReviewPage.css';

const ReviewPage = ({ preferences, onConfirmItinerary, onBackToForm }) => {
    return (
        <div id="reviewSection" className="card">
            <h2>Review Your Itinerary Draft</h2>
            <div className="itinerary-placeholder">
                <p>Your itinerary draft will be displayed here based on your inputs.</p>
                <p>For now, we'll assume it looks good!</p>
                {preferences && Object.keys(preferences).length > 0 && (
                    <>
                        <p><strong>Selected Preferences:</strong></p>
                        <ul>
                            {Object.entries(preferences)
                                .filter(([key, value]) => value)
                                .map(([key]) => (
                                    <li key={key}>{key.charAt(0).toUpperCase() + key.slice(1).replace(/([A-Z])/g, ' $1')}</li>
                                ))}
                        </ul>
                    </>
                )}
            </div>
            <div className="action-buttons-container">
                <button id="backToFormBtnReview" className="secondary-action-button" onClick={onBackToForm}>
                    Back to Form
                </button>
                <button id="confirmItineraryBtn" className="action-button" onClick={onConfirmItinerary}>
                    Confirm & Continue to Chat
                </button>
            </div>
        </div>
    );
};

export default ReviewPage;
