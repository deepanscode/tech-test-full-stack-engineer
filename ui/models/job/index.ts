export interface Job {
    id: number;
    status: string;
    suburbId: number;
    suburbName: string;
    postcode: string;
    categoryId: number;
    categoryName: string;
    contactName: string;
    contactPhone: string;
    contactEmail: string;
    price: number;
    description: string;
    createdAt: string;
    updatedAt: string;
}

export interface JobResult {
    jobs: Job[];
    totalRecordCount: number;
    pageNumber: number;
    pageSize: number;
}