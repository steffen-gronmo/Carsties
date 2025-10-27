'use client';

import React from "react";
import { getData } from "../actions/auctionActions";
import AppPagination from "../components/AppPagination";
import AuctionCard from "./AuctionCard";
import type { TAuction } from "./types";

export default function Listings() {
  const [auctions, setAuctions] = React.useState<TAuction[]>([]);
  const [pageCount, setPageCount] = React.useState(0);
  const [pageNumber, setPageNumber] = React.useState(1);

  React.useEffect(() => {
    getData(pageNumber).then(data => {
      setAuctions(data.results);
      setPageCount(data.pageCount);
    })
  }, [pageNumber]);

  if (auctions.length === 0) {
    return <h3>Loading...</h3>
  }

  return (
    <>
      <div className="grid grid-cols-4 gap-6">
        {auctions.map(auction => (
          <AuctionCard key={auction.id} auction={auction} />
        ))}
      </div>
      <div className="flex justify-center mt-4">
        <AppPagination currentPage={pageNumber} pageChanged={setPageNumber} pageCount={pageCount} />
      </div>
    </>
  );
}
