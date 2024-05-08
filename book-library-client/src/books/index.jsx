import { useEffect, useState } from "react";

import './books.css';
import { WEB_API } from "../consts";
import BookList from "./book-list";
import BookSearch from "./book-search";
import toQueryUrl from "../utils/to-query-url";

function Books() {
  const [books, setBooks] = useState([]);

  const getBooks = (query) => {
    fetch(`${WEB_API}/books${toQueryUrl(query)}`)
      .then(response => response.json())
      .then(data => setBooks(data));
  }

  useEffect(() => {
    getBooks();
  }, []);

  return (
    <div className="books">
      <h1>Royal Library</h1>
      <BookSearch onChange={getBooks}/>
      <BookList books={books}/>
    </div>
  )
}

export default Books;
