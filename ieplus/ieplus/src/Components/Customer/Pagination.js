import React from 'react';
import classes from './Pagination.module.css';

const Pagination = ({ postsPerPage, totalPosts, paginate }) => {
  const pageNumbers = [];
let SelectedPage=1;

  for (let i = 1; i <= Math.ceil(totalPosts / postsPerPage); i++) {
    pageNumbers.push(i);
  }

  return (
    <nav>
      <ul className={classes.ul}>
        {pageNumbers.map(number => (
          <li key={number} className={number==SelectedPage?classes.li:classes.liS}>
            <a onClick={() => paginate(number) }  >
              {number}
            </a>
          </li>
        ))}
      </ul>
    </nav>
  );
};

export default Pagination;