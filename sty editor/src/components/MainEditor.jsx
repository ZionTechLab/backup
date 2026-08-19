import { useEditor } from '../store/useEditorStore';
import PianoRoll from './tabs/PianoRoll';
import MixerTab  from './tabs/MixerTab';
import OTSEditor from './tabs/OTSEditor';
import StyleInfo from './tabs/StyleInfo';

const TABS = [
  { id: 'piano-roll', label: 'Piano Roll', icon: '♪' },
  { id: 'mixer',      label: 'Mixer',      icon: '≈' },
  { id: 'ots',        label: 'OTS',        icon: '⚙' },
  { id: 'info',       label: 'Info',       icon: 'ℹ' },
];

export default function MainEditor() {
  const { state, actions } = useEditor();
  const { activeTab, selectedSection } = state;

  return (
    <div
      className="flex flex-col flex-1 min-w-0 overflow-hidden"
      style={{ background: '#1a1a2e' }}
    >
      {/* Tab bar */}
      <div
        className="flex items-center gap-0 shrink-0"
        style={{ background: '#16213e', borderBottom: '1px solid #0f3460' }}
      >
        {TABS.map(tab => {
          const isActive = tab.id === activeTab;
          return (
            <button
              key={tab.id}
              onClick={() => actions.setActiveTab(tab.id)}
              className="flex items-center gap-1.5 px-4 h-9 text-xs font-medium transition-colors relative"
              style={{
                color: isActive ? '#eaeaea' : '#6b7280',
                background: isActive ? '#1a1a2e' : 'transparent',
                borderBottom: isActive ? '2px solid #e94560' : '2px solid transparent',
              }}
            >
              <span style={{ fontSize: 12 }}>{tab.icon}</span>
              {tab.label}
            </button>
          );
        })}

        {selectedSection && (
          <div
            className="ml-auto px-3 text-xs"
            style={{ color: '#9ca3af' }}
          >
            Section: <span style={{ color: '#e94560' }}>{selectedSection}</span>
          </div>
        )}
      </div>

      {/* Tab content */}
      <div className="flex-1 overflow-hidden">
        {activeTab === 'piano-roll' && <PianoRoll />}
        {activeTab === 'mixer'      && <MixerTab />}
        {activeTab === 'ots'        && <OTSEditor />}
        {activeTab === 'info'       && <StyleInfo />}
      </div>
    </div>
  );
}
