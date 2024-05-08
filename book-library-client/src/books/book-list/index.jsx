import './book-list.css';

function BookList({ books }) {

  const header = [
    'Book Title',
    'Publisher',
    'Authors',
    'Type',
    'ISBN',
    'Category',
    'Abailable Copies'
  ]

  const row = (book) => [
    book.title,
    book.lastName,
    book.firstName,
    book.type,
    book.isbn,
    book.category,
    `${book.copiesInUse}/${book.totalCopies}`
  ]

  return (
    <fieldset>
      <legend>Search Result:</legend>
      <table>
        <thead>
          <tr>{header.map(text => (<th key={text}>{text}</th>))}</tr>
        </thead>
        <tbody>
          {books.map(book => (
            <tr key={book.id}>{row(book).map(text => (<td>{text}</td>))}</tr>
          ))}
        </tbody>
      </table>
    </fieldset>
  )
}

export default BookList;
