import React, { useState, useEffect } from 'react';
import { useUser } from '../contexts/UserContext';
import { getTeamsByUserId } from '../data/api';
import './TeamsPage.css'; // We'll create this CSS file

const TeamsPage = () => {
  const { user, loading: userLoading } = useUser();
  const [teams, setTeams] = useState([]);
  const [loadingTeams, setLoadingTeams] = useState(true);

  useEffect(() => {
    if (user && user.id) {
      try {
        const userTeams = getTeamsByUserId(user.id);
        setTeams(userTeams);
      } catch (error) {
        console.error("Failed to fetch user's teams:", error);
        setTeams([]); // Set to empty array on error
      } finally {
        setLoadingTeams(false);
      }
    } else if (!userLoading) {
      // User is loaded but not available or no ID
      setLoadingTeams(false);
      setTeams([]);
    }
  }, [user, userLoading]);

  if (userLoading || loadingTeams) {
    return <div className="container card loading-message">Loading teams...</div>;
  }

  if (!user) {
    return <div className="container card info-message">Please log in to see your teams.</div>;
  }

  return (
    <div className="container teams-page card">
      <h2 className="page-title">My Teams</h2>
      {teams.length > 0 ? (
        <ul className="teams-list">
          {teams.map(team => (
            <li key={team.id} className="team-item card">
              <h3 className="team-name">{team.name}</h3>
              <p className="team-description">{team.description}</p>
              {/* Could add more details like member count if needed */}
            </li>
          ))}
        </ul>
      ) : (
        <p className="info-message">You haven't joined any teams yet.</p>
      )}
    </div>
  );
};

export default TeamsPage;
