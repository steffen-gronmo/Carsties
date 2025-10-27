'use client';

import { useParamsStore } from '@/hooks/useParamsStore';
import { useEffect, useState } from 'react'
import { FaSearch } from 'react-icons/fa'

const Search = () => {
  const [searchTerm, setSearchTerm] = useState('');

  const persistedSearchTerm = useParamsStore((state) => state.searchTerm);
  useEffect(() => setSearchTerm(persistedSearchTerm), [persistedSearchTerm]);

  const setParams = useParamsStore((state) => state.setParams);

  const onSearch = () => setParams({ searchTerm });

  return (
    <div className="flex w-[50%] items-center border-2 border-gray-300 rounded-full py-2 shadow-sm">
      <input
        type="text"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        onKeyDown={(e) => e.key === 'Enter' && onSearch()}
        placeholder="Search for cars by make, model or color"
        className={`
          flex-grow
          pl-5
          bg-transparent
          focus:outline-none
          border-transparent
          focus:border-transparent
          focus:ring-0
          text-sm
          text-gray-600
        `}
      />
      <button onClick={onSearch}>
        <FaSearch
          size={34}
          className="bg-red-400 text-white rounded-full p-2 cursor-pointer mx-2"
        />
      </button>
    </div>
  );
};

export default Search;
