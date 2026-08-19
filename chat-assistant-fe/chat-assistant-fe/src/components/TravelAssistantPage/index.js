import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useFormik } from "formik";
import * as Yup from "yup";
import ChatInterface from "../ChatInterface";
import {
  selectCurrentThreadId,
  setCurrentThreadId,
  clearCurrentThreadId,
  selectChatIsLoading,
  selectThreadData,
} from "../../features/chat/chatSlice";
import {
  initChatSession,
  sendMessageToThread,
} from "../../services/chatApiService";
import "./TravelAssistantPage.css";
import { initChat, sendMessage } from "../../features/chat/chatThunks";

const TravelAssistantPage = () => {
  const dispatch = useDispatch();

  const currentThreadIdFromStore = useSelector(selectCurrentThreadId);
  const isChatLoading = useSelector(selectChatIsLoading);
  const threadData = useSelector(selectThreadData);
  useEffect(() => {}, []);

  //   const [fullName, setFullName] = useState("");

  const [destination, setDestination] = useState("Sri Lanka");
  const [startPort, setStartPort] = useState("CMB");
  const [endPort, setEndPort] = useState("CMB");
  const [children, setChildren] = useState(0);
  const [infants, setInfants] = useState(0);
  const [preferences, setPreferences] = useState({
    nature: false,
    culture: false,
    adventure: false,
    relaxation: false,
    food: false,
    wildlife: false,
    historicalSites: false,
    luxury: false,
  });
  const [greetingName, setGreetingName] = useState("Traveler"); // Used in chat
  const [messages, setMessages] = useState([]);
  const [messageInput, setMessageInput] = useState("");

  const [currentView, setCurrentView] = useState("onboarding");
  const [isInitializingChat, setIsInitializingChat] = useState(false);
  const [chatInitError, setChatInitError] = useState(null);
  const [isSendingInitialMessage, setIsSendingInitialMessage] = useState(false);
  const [sendInitialMessageError, setSendInitialMessageError] = useState(null);
  const [isSendingUserMessage, setIsSendingUserMessage] = useState(false); // New state for user message sending
  const [sendUserMessageError, setSendUserMessageError] = useState(null); // New error state

  // 🔁 Fixed formatFormDataForMessage to use formik values
  const formatFormDataForMessage = () => {
    const { startDate, endDate, adults, comments } = formik.values;

    const selectedPreferences = Object.entries(preferences)
      .filter(([_, value]) => value)
      .map(
        ([key]) =>
          key.charAt(0).toUpperCase() + key.slice(1).replace(/([A-Z])/g, " $1")
      );

    let messageString = `Hay, i'm ${
      formik.values.fullName || "Not provided"
    }. Including myself ,${adults} Adults, ${children} Children, ${infants} Infants are planning to visit Sri Lanka from ${
      startDate || "N/A"
    } to ${endDate || "N/A"}. 
      my Preferences are ${selectedPreferences.join(
        ", "
      )}. Could you please help me with a itinerary?
      Additional Notes: ${comments}`;

    return messageString;
  };

  // eslint-disable-next-line no-undef
  // useEffect(scrollToBottom, [messages]);

  const formik = useFormik({
    initialValues: {
      fullName: "",
      // age: '', // Not included in current validation scope
      // originCountry: '', // Not included in current validation scope
      startDate: "",
      endDate: "",
      adults: 0, // Default to 0, validation will require >= 1
      comments: "",
    },
    validationSchema: Yup.object({
      fullName: Yup.string()
        .min(2, "Too short")
        .matches(/^[a-zA-Z\s]*$/, "Only letters and spaces are allowed")
        .required("Required"),
      startDate: Yup.date()
        .required("Required")
        .min(
          new Date(new Date().setHours(0, 0, 0, 0)),
          "Start date cannot be in the past"
        ), // Compare with start of today
      endDate: Yup.date()
        .required("Required")
        .min(Yup.ref("startDate"), "End date must be after start date"),
      adults: Yup.number()
        .required("Required")
        .min(1, "At least one adult is required")
        .integer("Must be a whole number"),
      comments: Yup.string().max(500, "Too long (max 500 characters)"),
    }),
    onSubmit: (values) => {
      setGreetingName(values.fullName || "Traveler");
      // Here you would typically send data to a backend or process it
      // For now, we'll just switch views
      console.log("Formik submitted, proceeding to review:", values);
      setCurrentView("review");
    },
  });

  // Need to sync Formik values to other state if they are used outside Formik context directly
  // For example, if handleStartPlanning was more complex and used original state vars.
  // However, with Formik, we primarily use formik.values.

  const handlePreferenceChange = (e) => {
    const { name, checked } = e.target;
    setPreferences((prev) => ({ ...prev, [name]: checked }));
  };

  const handleConfirmItinerary = async () => {
    const formDataMessage = formatFormDataForMessage();
    console.log("Formatted form data message:", formDataMessage);
    dispatch(sendMessage(formDataMessage));
    setCurrentView("chat");
  };

  // sendInitialFormDataMessage now uses the centralized API service
  const sendInitialFormDataMessage = async (threadId, messageContent) => {
    setIsSendingInitialMessage(true);
    setSendInitialMessageError(null);
    try {
      console.log(
        `Calling chatApiService.sendMessageToThread for initial form data (thread: ${threadId})...`
      );
      // The service function sendMessageToThread is generic.
      // 'initialFormData' helps the service log/simulate appropriately.
      const responseData = await sendMessageToThread(
        threadId,
        messageContent,
        "initialFormData"
      );
      console.log(
        "Initial form data message sent successfully via service:",
        responseData
      );
      console.log(messages);
      setMessages((prev) => [
        ...prev,
        {
          id: Date.now(),
          text: responseData.response,
          sender: "assistant",
        },
      ]);
    } catch (error) {
      console.error(
        "Error sending initial form data message via service:",
        error
      );
      setSendInitialMessageError(
        error.message || "Could not send your trip details."
      );
    } finally {
      setIsSendingInitialMessage(false);
    }
  };

  const handleBackToForm = () => {
    setCurrentView("onboarding");
  };

  const handleSendMessage = async () => {
    const trimmedMessage = messageInput.trim();
    if (!trimmedMessage) return;
    console.log("sent msg");

    console.log("Formatted form data message:", trimmedMessage);
    dispatch(sendMessage(trimmedMessage));
    setMessageInput("");
  };
  // or ChatInterface can have its own specific key press handler.
  // For now, we pass onSendMessage, and ChatInterface implements its own onKeyPress.

  return (
    <div
      className={`travel-assistant-content-wrapper main-content ${
        currentView === "chat" ? "chat-active" : ""
      }`}
    >
      {currentView === "onboarding" && (
        <form
          onSubmit={formik.handleSubmit}
          id="onboardingSection"
          className="onboarding-section"
        >
          <h2>Tell us about your trip</h2>

          <div className="card">
            <h3>Personal Information</h3>
            <div className="row">
              <div className="col-12">
              <div className="form-group">
                <label htmlFor="fullName">Full Name</label>
                <input
                  type="text"
                  id="fullName"
                  placeholder="John Smith"
                  name="fullName"
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                  value={formik.values.fullName}
                />
                {formik.touched.fullName && formik.errors.fullName ? (
                  <div className="error-message">{formik.errors.fullName}</div>
                ) : null}
              </div></div>
            </div>
          </div>

          <div className="card">
            <h3>Trip Details</h3>
            <div className="row">
              <div className="col-6 col-12-md ">
                <div className="form-group">
                  <label htmlFor="destination">Destination</label>
                  <select
                    id="destination"
                    value={destination}
                    onChange={(e) => setDestination(e.target.value)}
                  >
                    <option value="Sri Lanka">Sri Lanka</option>
                  </select>
                </div>
              </div>
              <div className="col-6">
                {/* <div className="form-group">
                <label htmlFor="destination">Destination</label>
                <select
                  id="destination"
                  value={destination}
                  onChange={(e) => setDestination(e.target.value)}
                >
                  <option value="Sri Lanka">Sri Lanka</option>
                </select>
              </div> */}
                <div className="form-group">
                  <label htmlFor="travelDates">Travel Dates</label>
                  <div className="date-inputs">
                    <input
                      type="date"
                      id="startDate"
                      name="startDate"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      value={formik.values.startDate}
                    />
                    <span>to</span>
                    <input
                      type="date"
                      id="endDate"
                      name="endDate"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      value={formik.values.endDate}
                    />
                  </div>
                  {formik.touched.startDate && formik.errors.startDate && (
                    <div className="travel-form-error-message">
                      {formik.errors.startDate}
                    </div>
                  )}
                  {formik.touched.endDate &&
                    formik.errors.endDate &&
                    !formik.errors.startDate && (
                      <div className="travel-form-error-message">
                        {formik.errors.endDate}
                      </div>
                    )}
                </div>
              </div>
            </div>
            <div className="grid-col-2">
              <div>
                <label htmlFor="startPort">Departure Port</label>
                <select
                  id="startPort"
                  value={startPort}
                  onChange={(e) => setStartPort(e.target.value)}
                >
                  <option value="CMB">
                    Bandaranaike International Airport (CMB)
                  </option>
                  <option value="HRI">
                    Mattala Rajapaksa International Airport (HRI)
                  </option>
                </select>
              </div>
              <div>
                <label htmlFor="endPort">Return Port</label>
                <select
                  id="endPort"
                  value={endPort}
                  onChange={(e) => setEndPort(e.target.value)}
                >
                  <option value="CMB">
                    Bandaranaike International Airport (CMB)
                  </option>
                  <option value="HRI">
                    Mattala Rajapaksa International Airport (HRI)
                  </option>
                </select>
              </div>
            </div>
          </div>

          <div className="card">
            <h3>Travel Party</h3>
            <div className="grid-col-3">
              <div className="form-input-group">
                <label htmlFor="adults">Adults</label>
                <input
                  type="number"
                  id="adults"
                  name="adults"
                  min="0"
                  placeholder="0"
                  className="input-number-small" // Added class
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                  value={formik.values.adults}
                />
                {formik.touched.adults && formik.errors.adults ? (
                  <div className="travel-form-error-message">
                    {formik.errors.adults}
                  </div>
                ) : null}
              </div>
              <div className="form-input-group">
                {" "}
                {/* Added form-input-group for consistency if errors were added later */}
                <label>Children</label>
                <input
                  type="number"
                  min="0"
                  placeholder="0"
                  className="input-number-small"
                  value={children}
                  onChange={(e) =>
                    setChildren(Math.max(0, parseInt(e.target.value) || 0))
                  }
                />
              </div>
              <div className="form-input-group">
                {" "}
                {/* Added form-input-group for consistency */}
                <label>Infants</label>
                <input
                  type="number"
                  min="0"
                  placeholder="0"
                  className="input-number-small"
                  value={infants}
                  onChange={(e) =>
                    setInfants(Math.max(0, parseInt(e.target.value) || 0))
                  }
                />
              </div>
            </div>
          </div>

          <div className="card">
            <h3>Travel Preferences</h3>
            <p className="preferences-description">Select all that apply:</p>
            <div className="grid-col-4 preferences-grid">
              {Object.keys(preferences).map((key) => (
                <label key={key} className="preference-item">
                  <input
                    type="checkbox"
                    name={key}
                    checked={preferences[key]}
                    onChange={handlePreferenceChange}
                  />
                  <span>
                    {key.charAt(0).toUpperCase() +
                      key.slice(1).replace(/([A-Z])/g, " $1")}
                  </span>
                </label>
              ))}
            </div>
          </div>

          <div className="card">
            <h3>Additional Notes</h3>
            <div className="form-input-group">
              <textarea
                id="comments"
                name="comments"
                rows="4"
                placeholder="Any special requirements or things we should know about your trip..."
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.comments}
              ></textarea>
              {formik.touched.comments && formik.errors.comments ? (
                <div className="travel-form-error-message">
                  {formik.errors.comments}
                </div>
              ) : null}
            </div>
          </div>

          <div className="action-button-container">
            <button
              type="submit"
              id="startPlanningBtn"
              className="action-button"
            >
              Start Trip Planning
            </button>
          </div>
        </form>
      )}

      {currentView === "review" && (
        <div id="reviewSection" className="card">
          <h2>Review Your Itinerary Draft</h2>
          <div className="itinerary-placeholder">
            <p>
              Your itinerary draft will be displayed here based on your inputs.{" "}
            </p>
            <p>For now, we'll assume it looks good!</p>
            <br />
            <p>
              <strong>Selected Preferences:</strong>
            </p>
            <ul>
              {Object.entries(preferences)
                .filter(([key, value]) => value)
                .map(([key]) => (
                  <li key={key}>
                    {key.charAt(0).toUpperCase() +
                      key.slice(1).replace(/([A-Z])/g, " $1")}
                  </li>
                ))}
            </ul>
          </div>
          <div className="action-button-container">
            <button
              id="confirmItineraryBtn"
              className="action-button"
              onClick={handleConfirmItinerary}
            >
              Confirm & Continue to Chat
            </button>
          </div>
        </div>
      )}

      {currentView === "chat" && (
        <ChatInterface
          messages={threadData}
          messageInput={messageInput}
          setMessageInput={setMessageInput}
          onSendMessage={handleSendMessage}
          onBackToForm={handleBackToForm}
          greetingName={greetingName}
          currentThreadId={currentThreadIdFromStore}
        />
      )}
    </div>
  );
};

export default TravelAssistantPage;
