import { useEffect, useState } from "react";

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
    <>
      <BookSearch onChange={getBooks}/>
      <BookList books={books}/>
    </>
  )
}

export default Books;
