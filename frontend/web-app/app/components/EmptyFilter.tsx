'use client';

import { Button } from "flowbite-react";
import Heading from "./Heading";
import { useParamsStore } from "@/hooks/useParamsStore";

type TProps = {
  showReset?: boolean;
  subtitle?: string;
  title?: string;
};

const EmptyFilter = ({
  showReset = false,
  subtitle = 'Try adjusting your filter or search term',
  title = 'No matches for this filter',
}: TProps) => {
  const reset = useParamsStore(state => state.reset);

  return (
    <div className="flex flex-col gap-2 items-center justify-center h-[40vh] shadow-lg">
      <Heading title={title} subtitle={subtitle} center />
      <div className="mt-4">
        {showReset && (
          <Button outline onClick={reset}>Remove filters</Button>
        )}
      </div>
    </div>
  );
};

export default EmptyFilter;
