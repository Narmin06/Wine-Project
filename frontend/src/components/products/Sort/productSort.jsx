import "./productSort.css";

export default function ProductSort({ onSortChange }) {
  const handleSortChange = (e) => {
    onSortChange(e.target.value);
  };

  return (
    <div className="sort-bar">
      <label htmlFor="sort">Sort by: </label>
      <select id="sort" onChange={handleSortChange}>
        <option value="name">Name (A-Z)</option>
        <option value="newest">Novelty</option>
      </select>
    </div>
  );
}
