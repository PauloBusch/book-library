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

  const handleExport = (query) => {
    fetch(`${WEB_API}/books/report${toQueryUrl(query)}`)
      .then(() => alert(
        'The report will be generated asynchronously.\n' + 
        'You\'ll get a notification soon with the link to download.'
      ));
  }

  useEffect(() => {
    handleSearch();
  }, []);

  return (
    <div className="books">
      <h1>Royal Library</h1>
      <BookSearch 
        onSearch={handleSearch}
        onExport={handleExport}/>
      <BookList books={books}/>
    </div>
  )
}

export default Books;
