'use server';

import type { TAuction } from "../auctions/types";

type TSearchResult = {
  results: TAuction[];
  pageCount: number;
  totalCount: number;
};

export const getData = async (pageNumber: number, pageSize: number = 4) => {
  const res = await fetch(`http://localhost:6001/search?pageSize=${pageSize}&pageNumber=${pageNumber}`);

  if (!res.ok) {
    throw new Error('Failed to fetch data');
  }

  return res.json() as Promise<TSearchResult>;
};
