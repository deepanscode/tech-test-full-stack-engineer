import {useQuery, UseQueryResult} from '@tanstack/react-query'
import {JobStatus} from "@/enums";

const fetchJobs = async (page: number, size: number, status?: JobStatus): Promise<UseQueryResult<Job[], Error>> => {
    let params: string = `PageNumber=${page.toString()}&PageSize=${size.toString()}`;
    if (status) params = params.concat(`&JobStatus=${status.toString()}`);

    const url = `http://localhost:8080/api/v1.0/Jobs?${params}`;
    const response = await fetch(url);

    if (!response.ok) throw new Error("Failed to fetch!");
    const data: any = await response.json();
    return data['data'];
}
const updateJobStatus = async (id: number, status: JobStatus) => {
    const response = await fetch(`http://localhost:8080/api/v1.0/Jobs/${id}`, {
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

const useJobs = (page: number = 1, size: number = 10, status?: JobStatus) => {
    return useQuery({
        queryKey: ['jobs', page, size, status],
        queryFn: () => fetchJobs(page, size, status),
    });
}

export {useJobs, fetchJobs, updateJobStatus}
