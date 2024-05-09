import { useState } from "react";

import './book-search.css';

function BookSearch({ onSearch }) {
  const [field, setField] = useState('title');
  const [value, setValue] = useState('');

  return (
    <fieldset>
      <div className="field">
        <label htmlFor="search-by">Search By:</label>
        <select id="search-by" onChange={ev => setField(ev.target.value)}>
          <option value="title">Title</option>
          <option value="author">Author</option>
          <option value="isbn">ISBN</option>
          <option value="category">Category</option>
        </select>
      </div>
      <div className="field">
        <label htmlFor="search-value">Search Value:</label>
        <input id="search-value" onChange={ev => setValue(ev.target.value)}/>
      </div>
      <button onClick={() => onSearch({ [field]: value })}>Search</button>
    </fieldset>
  )
}

export default BookSearch;
