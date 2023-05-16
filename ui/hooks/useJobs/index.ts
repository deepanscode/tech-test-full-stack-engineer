import {useInfiniteQuery} from '@tanstack/react-query'
import {JobStatus} from "@/enums";
import { JobResult } from '@/models/job';

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;

const fetchJobs = async (page: number, size: number, status?: JobStatus): Promise<JobResult> => {
    let params = `PageNumber=${page.toString()}&PageSize=${size.toString()}`;
    if (status) params = params.concat(`&JobStatus=${status.toString()}`);

    const url = `${BASE_URL}/api/v1.0/Jobs?${params}`;
    console.log(BASE_URL);
    const response = await fetch(url);

    if (!response.ok) throw new Error("Failed to fetch!");
    const { data, ...metadata } = await response.json();
    return { jobs: data, ...metadata } as JobResult;
}
const updateJobStatus = async (id: number, status: JobStatus) => {
    const response = await fetch(`${BASE_URL}/api/v1.0/Jobs/${id}`, {
        body: JSON.stringify({"jobStatus": status}),
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            credentials: "include",
        },
        method: "PUT"
    })
    if (!response.ok) throw new Error("Failed to update!");
}

const useJobs = (size = 10, status?: JobStatus) => {
    return useInfiniteQuery({
        queryKey: ['jobs', status],
        queryFn: ({ pageParam = 1 }) => fetchJobs(pageParam, size, status),
        getNextPageParam: (lastPage) => {
            const totalPages = Math.ceil(lastPage.totalRecordCount / lastPage.pageSize);
            return lastPage.pageNumber < totalPages ? lastPage.pageNumber + 1 : false;
        },
    });
}


export {useJobs, fetchJobs, updateJobStatus};
