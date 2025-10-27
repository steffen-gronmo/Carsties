'use client';

import { Pagination } from "flowbite-react";
import React from "react";

type TProps = {
  currentPage: number;
  pageChanged: (page: number) => void
  pageCount: number;
}

const AppPagination = ({
  currentPage,
  pageChanged,
  pageCount,
}: TProps) => {
  return (
    <Pagination
      currentPage={currentPage}
      onPageChange={(page) => pageChanged(page)}
      totalPages={pageCount}
      layout="pagination"
      showIcons
      className="text-blue-500 mb-5"
    />
  );
};

export default AppPagination;
