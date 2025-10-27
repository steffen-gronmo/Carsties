import AuctionCard from "./AuctionCard";
import type { TAuction } from "./types";

type TSearchResult = {
  results: TAuction[];
  pageCount: number;
  totalCount: number;
};

const getData = async () => {
  const res = await fetch('http://localhost:6001/search?pageSize=10');

  if (!res.ok) {
    throw new Error('Failed to fetch data');
  }

  return res.json() as Promise<TSearchResult>;
};

export default async function Listings() {
  const data = await getData();
  return (
    <div className="grid grid-cols-4 gap-6">
      {data && data.results.map(auction => (
        <AuctionCard key={auction.id} auction={auction} />
      ))}
    </div>
  );
}
