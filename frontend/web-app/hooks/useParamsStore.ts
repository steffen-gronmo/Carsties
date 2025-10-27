import { create } from "zustand";

type TState = {
  filterBy: 'live' | 'endingSoon' | 'finished';
  orderBy: 'make' | 'endingSoon' | 'new';
  pageCount: number;
  pageNumber: number;
  pageSize: number;
  searchTerm: string;
};

type TActions = {
  reset: () => void;
  setParams: (params: Partial<TState>) => void;
};

const initialState: TState = {
  filterBy: 'live',
  orderBy: 'make',
  pageCount: 1,
  pageNumber: 1,
  pageSize: 12,
  searchTerm: '',
};

export const useParamsStore = create<TState & TActions>((set) => ({
  ...initialState,
  reset: () => set(() => ({ ...initialState })),
  setParams: (params) => set((state) => {
    if ('pageNumber' in params) {
      return { ...state, pageNumber: params.pageNumber };
    }

    // Always reset pageNumber to 1 when other params change
    return {
      ...state,
      ...params,
      pageNumber: 1,
    };
  }),
}));
