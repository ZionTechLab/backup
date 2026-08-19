const SIZE_CLASS = {
  sm: 'fs-6',
  md: 'fs-5',
  lg: 'fs-4',
};

export default function StatCard({ title, value, color = 'primary', size = 'md', className = '' }) {
  const sizeClass = SIZE_CLASS[size] || SIZE_CLASS.md;

  return (
    <div className={`card text-center h-100 border-${color} ${className}`}>
      <div className={`card-header py-1 small text-bg-${color} text-nowrap`}>{title}</div>
      <div className="card-body py-2 d-flex align-items-center justify-content-center">
        <div className={`${sizeClass} fw-bold`}>{value}</div>
      </div>
    </div>
  );
}
