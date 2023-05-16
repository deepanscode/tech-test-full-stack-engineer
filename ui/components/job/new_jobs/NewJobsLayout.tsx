import {useState} from "react";
import {fetchJobs, useJobs} from "@/hooks";
import {JobStatus} from "@/enums";
import NewJob from "@/components/job/new_jobs/NewJob";
import {dehydrate, QueryClient} from "@tanstack/react-query";

export default function NewJobsLayout() {
    const [page] = useState<number>(1);
    const [size] = useState<number>(10);
    const [status] = useState<JobStatus>(JobStatus.new);

    const {data = [], isLoading, isFetching} = useJobs(page, size, status);

    return (isLoading ? <div>loading...</div> : data.map((d: Job) => <NewJob key={d.id} job={d}/>))
}

export async function getStaticProps() {
    const queryClient = new QueryClient()

    await queryClient.prefetchQuery({
        queryKey: ['jobs', 10],
        queryFn: () => fetchJobs(1, 10, JobStatus.new),
    })

    return {
        props: {
            dehydratedState: dehydrate(queryClient),
        },
    }
}