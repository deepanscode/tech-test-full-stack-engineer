import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faMapMarkerAlt, faSuitcase} from '@fortawesome/free-solid-svg-icons';
import format from "date-fns/format";
import {JobStatus} from "@/enums";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {updateJobStatus} from "@/hooks/useJobs";
import { Job } from '@/models/job';

interface Props {
    job: Job
}

export default function NewJob({job}: Props) {
    const queryClient = useQueryClient();
    const mutation = useMutation({
        mutationFn: ({id, status}: { id: number, status: JobStatus }) => updateJobStatus(id, status),
        onSuccess: () => {
            queryClient.invalidateQueries(['jobs', JobStatus.new]);
            queryClient.invalidateQueries(['jobs', JobStatus.accepted]);
        }
    })
    return (
        <div className="card-body">
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex items-center">
                        <div className="badge-user-icon">
                            <span>{job.contactName.charAt(0).toUpperCase() ?? "-"}</span>
                        </div>
                        <div>
                            <h2 className="font-semibold text-secondarydark">{job.contactName.split(" ")[0] ?? "-"}</h2>
                            <p className="text-secondary text-sm">{format(new Date(job.createdAt), "MMMM dd yyyy") + ' @ ' + format(new Date(job.createdAt), "hh:mm aaa")}</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex text-secondary text-sm">
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faMapMarkerAlt} className="text-secondary mr-2"/>
                            <span>{job.suburbName + " " + job.postcode}</span>
                        </div>
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faSuitcase} className="text-secondary mr-2"/>
                            <span>{job.categoryName}</span>
                        </div>
                        <div className="flex items-center">
                            <span>Job ID:</span>
                            <span className="ml-2">{job.id}</span>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <p className="text-secondary text-sm">{job.description}</p>
                </div>
            </div>
            <div className="px-6 py-4">
                <div className="flex items-center">
                    <button className="btn-primary"
                            onClick={() => mutation.mutate({id: job.id, status: JobStatus.accepted})}>Accept
                    </button>
                    <button className="btn-secondary"
                            onClick={() => mutation.mutate({id: job.id, status: JobStatus.declined})}>Decline
                    </button>
                    <div className="ml-8">
                        <span className="text-secondarydark font-semibold">${job.price.toFixed(2)}</span>
                        <span className="text-secondary ml-2">Lead Invitation</span>
                    </div>
                </div>
            </div>
        </div>
    )
}
