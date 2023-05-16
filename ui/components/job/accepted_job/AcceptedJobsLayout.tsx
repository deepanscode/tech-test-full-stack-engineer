import {useState} from "react";
import {fetchJobs, useJobs} from "@/hooks";
import {JobStatus} from "@/enums";
import AcceptedJob from "@/components/job/accepted_job/AcceptedJob";
import {dehydrate, QueryClient} from "@tanstack/react-query";

export default function AcceptedJobsLayout() {
    const [page] = useState<number>(1);
    const [size] = useState<number>(10);
    const [status] = useState<JobStatus>(JobStatus.accepted);

    const {data = [], isLoading} = useJobs(page, size, status);

    return (isLoading ? <div>loading...</div> : data.map((d: Job) => <AcceptedJob key={d.id} job={d}/>))
}

export async function getStaticProps() {
    const queryClient = new QueryClient()

    await queryClient.prefetchQuery({
        queryKey: ['jobs', 10],
        queryFn: () => fetchJobs(1, 10, JobStatus.accepted),
    })

    return {
        props: {
            dehydratedState: dehydrate(queryClient),
        },
    }
}
