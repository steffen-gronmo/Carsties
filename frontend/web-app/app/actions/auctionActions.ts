'use server';

import type { TAuction } from "../auctions/types";

export type TData = {
  results: TAuction[];
  pageCount: number;
  totalCount: number;
};

export const getData = async (query: string) => {
  const res = await fetch(`http://localhost:6001/search${query}`);

  if (!res.ok) {
    throw new Error('Failed to fetch data');
  }

  return res.json() as Promise<TData>;
};
