import { useMediaQuery } from './useMediaQuery';

// Page navigation. Shows a compact window of page numbers with ellipses on
// small screens, a wider window on desktop. Hidden when there is one page.
export function Pagination({ total = 0, currentPage = 1, pageSize = 10, onPageChange }) {
  const safeTotal = typeof total === 'number' && total >= 0 ? total : 0;
  const totalPages = Math.ceil(safeTotal / pageSize);
  const isSmallScreen = useMediaQuery('(max-width: 575.98px)');

  if (totalPages <= 1) return null;

  const getPageNumbers = () => {
    const pages = [];

    if (isSmallScreen) {
      if (totalPages <= 5) {
        for (let i = 1; i <= totalPages; i++) pages.push(i);
      } else {
        pages.push(1);
        if (currentPage > 3) pages.push('ellipsis-start');
        const start = Math.max(2, currentPage - 1);
        const end = Math.min(totalPages - 1, currentPage + 1);
        for (let i = start; i <= end; i++) pages.push(i);
        if (currentPage < totalPages - 2) pages.push('ellipsis-end');
        pages.push(totalPages);
      }
    } else {
      const showEllipsis = totalPages > 7;
      if (!showEllipsis) {
        for (let i = 1; i <= totalPages; i++) pages.push(i);
      } else {
        pages.push(1, 2);
        if (currentPage <= 4) {
          pages.push(3, 4, 5);
          pages.push('ellipsis-end');
        } else if (currentPage >= totalPages - 3) {
          pages.push('ellipsis-start');
          pages.push(totalPages - 4, totalPages - 3, totalPages - 2);
        } else {
          pages.push('ellipsis-start');
          pages.push(currentPage - 1, currentPage, currentPage + 1);
          pages.push('ellipsis-end');
        }
        pages.push(totalPages - 1, totalPages);
      }
    }

    return pages.filter((page, index, self) => self.indexOf(page) === index);
  };

  const pageNumbers = getPageNumbers();

  const paginationStyle = {
    fontSize: 'clamp(0.7rem, 2vw, 1rem)',
  };

  return (
    <nav aria-label="Pagination">
      <ul className="pagination ravonix-pagination justify-content-center justify-content-sm-end flex-wrap" style={paginationStyle} aria-label="Pagination navigation">
        <li className={`page-item ${currentPage === 1 ? 'disabled' : ''}`}>
          <button
            className="page-link"
            onClick={() => currentPage > 1 && onPageChange(currentPage - 1)}
            disabled={currentPage === 1}
            aria-label="Previous page"
          >
            {'‹'}
          </button>
        </li>

        {pageNumbers.map((page, index) => {
          if (typeof page === 'string' && page.startsWith('ellipsis')) {
            return (
              <li key={page} className="page-item disabled" aria-hidden="true">
                <span className="page-link">...</span>
              </li>
            );
          }
          return (
            <li key={index} className={`page-item ${page === currentPage ? 'active' : ''}`}>
              <button
                className="page-link"
                onClick={() => onPageChange(page)}
                aria-label={`Page ${page}`}
                aria-current={page === currentPage ? 'page' : undefined}
              >
                {page}
              </button>
            </li>
          );
        })}

        <li className={`page-item ${currentPage === totalPages ? 'disabled' : ''}`}>
          <button
            className="page-link"
            onClick={() => currentPage < totalPages && onPageChange(currentPage + 1)}
            disabled={currentPage === totalPages}
            aria-label="Next page"
          >
            {'›'}
          </button>
        </li>
      </ul>
    </nav>
  );
}
