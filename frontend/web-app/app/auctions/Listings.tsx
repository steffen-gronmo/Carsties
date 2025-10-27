'use client';

import React from "react";
import { getData, type TData } from "../actions/auctionActions";
import AppPagination from "../components/AppPagination";
import AuctionCard from "./AuctionCard";
import Filters from "./Filters";
import { useParamsStore } from "@/hooks/useParamsStore";
import { useShallow } from "zustand/shallow";
import qs from "query-string";

export default function Listings() {
  const [data, setData] = React.useState<TData | null>(null);
  
  const params = useParamsStore(useShallow(state => ({
    pageNumber: state.pageNumber,
    pageSize: state.pageSize,
    pageCount: state.pageCount,
    searchTerm: state.searchTerm,
  })));
  const setParams = useParamsStore(state => state.setParams);

  const query = qs.stringifyUrl({ url: '', query: params }, { skipEmptyString: true, skipNull: true });

  const setPageNumber = (pageNumber: number) => setParams({ pageNumber });

  React.useEffect(() => {
    getData(query).then(data => setData(data));
  }, [query]);

  if (!data) {
    return <h3>Loading...</h3>
  }

  return (
    <>
      <Filters />
      <div className="grid grid-cols-4 gap-6">
        {data.results.map(auction => (
          <AuctionCard key={auction.id} auction={auction} />
        ))}
      </div>
      <div className="flex justify-center mt-4">
        <AppPagination
          currentPage={params.pageNumber}
          pageChanged={setPageNumber}
          pageCount={params.pageCount}
        />
      </div>
    </>
  );
}
