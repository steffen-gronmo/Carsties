'use client';

import { useParamsStore } from '@/hooks/useParamsStore';
import React from 'react'
import { FaSearch } from 'react-icons/fa'

export default function Search() {
  const [searchInput, setSearchInput] = React.useState('');

  const setParams = useParamsStore((state) => state.setParams);

  const onSearch = () => setParams({ searchTerm: searchInput });

  return (
    <div className="flex w-[50%] items-center border-2 border-gray-300 rounded-full py-2 shadow-sm">
      <input
        type="text"
        value={searchInput}
        onChange={(e) => setSearchInput(e.target.value)}
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
  )
}
