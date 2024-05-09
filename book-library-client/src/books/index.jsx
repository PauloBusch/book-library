import { useEffect, useState } from "react";

import './books.css';
import { WEB_API } from "../consts";
import BookList from "./book-list";
import BookSearch from "./book-search";
import toQueryUrl from "../utils/to-query-url";

function Books() {
  const [books, setBooks] = useState([]);

  const handleSearch = (query) => {
    fetch(`${WEB_API}/books${toQueryUrl(query)}`)
      .then(response => response.json())
      .then(data => setBooks(data));
  }

  useEffect(() => {
    handleSearch();
  }, []);

  return (
    <div className="books">
      <h1>Royal Library</h1>
      <BookSearch onSearch={handleSearch}/>
      <BookList books={books}/>
    </div>
  )
}

export default Books;
