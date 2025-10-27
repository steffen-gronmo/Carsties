import { create } from "zustand";

type TState = {
  pageNumber: number;
  pageSize: number;
  pageCount: number;
  searchTerm: string;
};

type TActions = {
  setParams: (params: Partial<TState>) => void;
  reset: () => void;
};

const initialState: TState = {
  pageNumber: 1,
  pageSize: 12,
  pageCount: 1,
  searchTerm: '',
};

export const useParamsStore = create<TState & TActions>((set) => ({
  ...initialState,
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
  reset: () => set(() => ({ ...initialState })),
}));
