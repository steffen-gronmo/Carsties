'use client';

import Image from "next/image";
import React from "react";
import type { TAuction } from "./types";

type TProps = {
  auction: TAuction;
};

export default function CarImage({ auction }: TProps) {
  const [isLoading, setIsLoading] = React.useState(true);
  return (
    <Image
      src={auction.imageUrl}
      className={`
        object-cover duration-700 ease-in-out
        ${isLoading ? 'opacity-0 scale-110' : 'opacity-100 scale-100'}
      `}
      onLoad={() => setIsLoading(false)}
      alt={`${auction.make} ${auction.model}`}
      layout="fill"
      priority
      sizes="(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 25vw"
    />
  );
}
